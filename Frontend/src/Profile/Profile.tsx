import ProfileAdmin from "./profile-admin.tsx";
import ProfilePatient from "./profile-patient.tsx";
import ProfileDoctor from "./profile-doctor.tsx";
import React from "react";
import "./profile.css";
import Sidebar from "../Dashboard/src/layout/Sidebar/Sidebar.jsx";
export default function MyProfile({ role }) {
  if (role === "Patient") {
    return (
      <div className="app profile">
        <Sidebar role={role} />
        <ProfilePatient />;
      </div>
    );
  } else if (role === "Doctor") {
    return (
      <div className="app profile">
        <Sidebar role={role} />
        <ProfileDoctor />;
      </div>
    );
  } else if (role === "Admin") {
    return (
      <div className="app profile">
        <Sidebar role={role} />
        <ProfileAdmin />;
      </div>
    );
  }
}
