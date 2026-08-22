import LoginButton from "./components/loginButton";
import CancelButton from "./components/cancelButton";
import "./loginPage.css"; // Import CSS file globally
import { useState } from "react";

export default function LoginPage() {
  return (
    <>
      <div className="login-box">
        <h1 className="title">Login Page</h1>
        <div className="email-input">
          <input></input>
        </div>
        <div className="password-input">
          <input></input>
        </div>
        <div className="button-group">
          <LoginButton />
          <CancelButton />
        </div>
        <a href="/new-user" target="blank" className="new-user">
          New User
        </a>
      </div>
    </>
  );
}
