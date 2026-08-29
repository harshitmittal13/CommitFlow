export interface CreateNewUserRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
}

export interface CreateNewUserResponse {
  message: string;
  userId: string;
}
