import "./loginPage.css";
import { useState } from "react";
import Button from "@mui/material/Button";
import axios from "axios";
import { useLoginStore } from "../../store/Login/store";

export default function LoginPage() {
  const login = useLoginStore((state) => state.login);
  const isLoading = useLoginStore((state) => state.isLoading);

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async () => {
    if (!email.trim()) {
      alert("Email is required.");
      return;
    }

    if (!password) {
      alert("Password is required.");
      return;
    }

    try {
      await login({
        email,
        password,
      });

      // Login successful
      console.log("Login successful");
    } catch (error) {
      if (axios.isAxiosError(error)) {
        if (error.response?.status === 401) {
          alert("Invalid email or password.");
        } else if (error.response?.status === 400) {
          alert(error.response?.data?.message);
        } else if (error.response?.status === 500) {
          alert("Server error. Please try again later.");
        } else if (!error.response) {
          alert("Unable to connect to the server.");
        } else {
          alert(error.response?.data?.message ?? "Something went wrong.");
        }
      } else {
        alert("An unexpected error occurred.");
      }
    }
  };

  const handleCancel = () => {
    setEmail("");
    setPassword("");
  };

  return (
    <>
      <div className="login-box">
        <h1 className="title">Login Page</h1>

        <div className="email-input">
          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
        </div>

        <div className="password-input">
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>

        <div className="button-group">
          <Button
            variant="contained"
            onClick={handleLogin}
            disabled={isLoading}
          >
            {isLoading ? "Logging in..." : "Login"}
          </Button>

          <Button
            variant="contained"
            onClick={handleCancel}
            disabled={isLoading}
          >
            Cancel
          </Button>
        </div>

        <a href="/new-user" className="new-user">
          New User
        </a>
      </div>
    </>
  );
}
