import { create } from "zustand";
import { postAuth } from "./action/postAuth";
import type { LoginRequest } from "./type";

interface LoginState {
  isLoading: boolean;
  isAuthenticated: boolean;
  authToken: string | null;
  error: string | null;

  login: (data: LoginRequest) => Promise<void>;
  logout: () => void;
}

export const useLoginStore = create<LoginState>((set) => ({
  isLoading: false,

  authToken: localStorage.getItem("authToken"),

  isAuthenticated: !!localStorage.getItem("authToken"),

  error: null,

  login: async (data) => {
    try {
      set({
        isLoading: true,
        error: null,
      });

      const response = await postAuth(data);

      // Save JWT
      localStorage.setItem("authToken", response.authToken);

      set({
        isLoading: false,
        isAuthenticated: true,
        authToken: response.authToken,
        error: null,
      });
    } catch (error) {
      set({
        isLoading: false,
        isAuthenticated: false,
        error: "Authentication failed.",
      });

      throw error;
    }
  },

  logout: () => {
    localStorage.removeItem("authToken");

    set({
      isAuthenticated: false,
      authToken: null,
      error: null,
    });
  },
}));
