import React from "react";
import Sidebar from "../layout/Sidebar/Sidebar";
import DoctorListPageContent from "./DoctorListPageContent.tsx";

export default function DoctorListPage()
{
    return (
      
            <div className="app profile">
              <Sidebar role={'Admin'} />
              <DoctorListPageContent/>;
            </div>
);
}