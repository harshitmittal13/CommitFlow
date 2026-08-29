import { create } from "zustand";
import { postCreateNewUser } from "./action/postCreateNewUser";
import type { CreateNewUserRequest } from "./type";

interface CreateNewUserState {
  isLoading: boolean;
  isAuthenticated: boolean;
  userId: string | null;
  error: string | null;

  createNewUser: (data: CreateNewUserRequest) => Promise<void>;
  logout: () => void;
}

export const useCreateNewUserStore = create<CreateNewUserState>((set) => ({
  isLoading: false,

  userId: localStorage.getItem("userId"),

  isAuthenticated: !!localStorage.getItem("userId"),

  error: null,

  createNewUser: async (data) => {
    try {
      console.log("Creating user with:", data);

      set({
        isLoading: true,
        error: null,
      });

      const response = await postCreateNewUser(data);

      console.log("Create user response:", response);

      localStorage.setItem("userId", response.userId);

      set({
        isLoading: false,
        isAuthenticated: true,
        userId: response.userId,
        error: null,
      });
    } catch (error) {
      console.error("Create user failed:", error);

      set({
        isLoading: false,
        isAuthenticated: false,
        error: "Failed to create user.",
      });

      throw error;
    }
  },

  logout: () => {
    localStorage.removeItem("userId");

    set({
      isAuthenticated: false,
      userId: null,
      error: null,
    });
  },
}));
