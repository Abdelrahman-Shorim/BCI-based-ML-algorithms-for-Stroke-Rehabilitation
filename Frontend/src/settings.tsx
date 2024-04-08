import React from "react";
import Sidebar from "./Dashboard/src/layout/Sidebar/Sidebar";
import { Button } from "@mui/material";
export default function Settings()
{
    return(
        <div className="app profile">
        <Sidebar role={'Admin'} />
        <h1 style={{color:'white'}}> Settings</h1>
        <Button variant="outlined"  color="error"  style={{width:'10vh',height:'10vh', position:'relative',top:'50vh',left:'50vh'}} >
        Logout
      </Button>
        </div>
    )
}