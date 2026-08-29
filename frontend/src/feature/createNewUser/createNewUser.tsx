import "./createNewUser.css";
import { useState } from "react";
import Button from "@mui/material/Button";
import axios from "axios";
import { useCreateNewUserStore } from "../../store/createNewUser/store";

export default function CreateNewUser() {
  const createNewUser = useCreateNewUserStore((state) => state.createNewUser);
  const isLoading = useCreateNewUserStore((state) => state.isLoading);
  const [firstName, setfirstName] = useState("");
  const [lastName, setlastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleCreate = async () => {
    if (!firstName) {
      alert("First Name is required.");
      return;
    }

    if (!lastName) {
      alert("Last Name is required.");
      return;
    }

    if (!email.trim()) {
      alert("Email is required.");
      return;
    }

    if (!password) {
      alert("Password is required.");
      return;
    }

    if (password.trim().length < 6) {
      alert("Password should have minimum 6 characters.");
      return;
    }

    try {
      await createNewUser({
        firstName,
        lastName,
        email,
        password,
      });

      // Login successful
      console.log("User Created successfully");
    } catch (error) {
      if (axios.isAxiosError(error)) {
        if (error.response?.status === 400) {
          alert(error.response?.data?.message);
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
    setfirstName("");
    setlastName("");
  };

  return (
    <>
      <div className="login-box">
        <h1 className="title">New User</h1>

        <div className="first-name-input">
          <input
            type="text"
            placeholder="First Name"
            value={firstName}
            onChange={(e) => setfirstName(e.target.value)}
          />
        </div>

        <div className="last-name-input">
          <input
            type="text"
            placeholder="Last Name"
            value={lastName}
            onChange={(e) => setlastName(e.target.value)}
          />
        </div>

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
            onClick={handleCreate}
            disabled={isLoading}
          >
            {isLoading ? "Creating..." : "Create"}
          </Button>

          <Button
            variant="contained"
            onClick={handleCancel}
            disabled={isLoading}
          >
            Cancel
          </Button>
        </div>
      </div>
    </>
  );
}
