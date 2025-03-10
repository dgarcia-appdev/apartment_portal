import Login from "./components/login/Login";
import { BrowserRouter, Routes, Route } from "react-router";
import Home from "./components/Home/Home";
import UserProfile from "./components/UserProfile";
import "./App.css";
import {
  FormDemo,
  TenantDashboard,
} from "./pages";
// import ManageGuests from "./pages/ManageGuests";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/home" element={<Home />} />
        <Route path="/users/:id" element={<UserProfile />} />
        <Route path="/formdemo" element={<FormDemo />} />
        {/* <Route path="/guests" element={<ManageGuests />} /> */}
        <Route path="/tenantdashboard" element={<TenantDashboard />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
