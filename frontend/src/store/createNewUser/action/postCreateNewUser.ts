import axios from "axios";
import type { CreateNewUserRequest, CreateNewUserResponse } from "../type";

const baseUrl = import.meta.env.VITE_BASE_LOGIN_URL;
const path = import.meta.env.VITE_CREATE_NEW_USER_URL;

export const postCreateNewUser = async (
  data: CreateNewUserRequest,
): Promise<CreateNewUserResponse> => {
  const response = await axios.post<CreateNewUserResponse>(
    `${baseUrl}${path}`,
    data,
  );
  return response.data;
};
