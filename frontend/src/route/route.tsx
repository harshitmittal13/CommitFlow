import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Navigate,
} from "react-router-dom";
import CreateNewUser from "../feature/createNewUser/createNewUser";
import LoginPage from "../feature/loginPage/loginPage";

export default function AppRoutes() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Navigate to="/login" replace />} />
        <Route path="/new-user" element={<CreateNewUser />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="*" element={<h1>404 Page not found</h1>} />
      </Routes>
    </Router>
  );
}
