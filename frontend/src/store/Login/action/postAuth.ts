import axios from "axios";
import type { LoginRequest, LoginResponse } from "../type";

const baseUrl = import.meta.env.VITE_BASE_LOGIN_URL;
const path = import.meta.env.VITE_LOGIN_URL;

export const postAuth = async (data: LoginRequest): Promise<LoginResponse> => {
  const response = await axios.post<LoginResponse>(`${baseUrl}${path}`, data);

  return response.data;
};
