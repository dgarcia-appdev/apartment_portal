import { Routes, Route, redirect } from "react-router-dom";
import Login from "./pages/shared/Login";

import UserProfile from "./components/UserProfile";
import ReportIssue from "./pages/guest/ReportIssue";
import "./App.css";
import Layout from "./components/Layout";
import { TenantDashboard } from "./pages";
import ManageGuests from "./pages/ManageGuests";
import AdminDashboard from "./pages/AdminDashboard";
import ErrorPage from "./pages/shared/Error";
import { useEffect, useState } from "react";
import { CurrentUserResponseType } from "./Types";
import { getData } from "./services/api";
import useGlobalContext from "./hooks/useGlobalContext";
import { getUserRoles } from "./services/auth";

function App() {
  const { setUser } = useGlobalContext();
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    (async () => {
      try {
        const currentUserResponse = await getData<CurrentUserResponseType>(
          "users/currentuser"
        );

        if (!currentUserResponse.id) {
          setIsLoading(false);
          redirect("/");
          return;
        }

        const roles = await getUserRoles();

        setUser({
          userId: currentUserResponse.id,
          userName: currentUserResponse.userName,
          firstName: currentUserResponse.firstName,
          lastName: currentUserResponse.lastName,
          roles: roles,
        });
      } catch (error) {
        console.error("Error getting current user:", error);
        redirect("/");
      } finally {
        setIsLoading(false);
      }
    })();
  }, [setUser]);

  if (isLoading) return <h1>Loading App...</h1>;

  return (
    <Routes>
      <Route element={<Layout usersRole={"Admin"} />}>
        <Route path="/admindashboard" element={<AdminDashboard />} />
        <Route path="/users/:id" element={<UserProfile />} />
        <Route path="/reportissue" element={<ReportIssue />} />
      </Route>
      <Route element={<Layout usersRole={"Tenant"} />}>
        <Route path="/guests" element={<ManageGuests />} />
        <Route path="/reportissue" element={<ReportIssue />} />
        <Route path="/tenantdashboard" element={<TenantDashboard />} />
      </Route>
      <Route path="/error" element={<ErrorPage />} />
      <Route path="/" element={<Login />} />
      <Route path="*" element={<ErrorPage />} />
    </Routes>
  );
}

export default App;
