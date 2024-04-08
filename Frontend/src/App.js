import logo from "./logo.svg";
import "./App.css";
import * as React from "react";
import Button from "@mui/joy/Button";
import FormControl from "@mui/joy/FormControl";
import FormLabel from "@mui/joy/FormLabel";
import Input from "@mui/joy/Input";
import Modal from "@mui/joy/Modal";
import ModalDialog from "@mui/joy/ModalDialog";
import DialogTitle from "@mui/joy/DialogTitle";
import DialogContent from "@mui/joy/DialogContent";
import Stack from "@mui/joy/Stack";
import Add from "@mui/icons-material/Add";
import JoySignInSideTemplate from "./SignIn/Signin.tsx";
import Header from './Containers/Header/header';
import Signup from "./SignUp/Signup.tsx";
import Signin from "./SignIn/Signin.tsx";
import Navbar from './LandingPage/navbar/Navbar';
import Front from './LandingPage/Front';
import Dashboard from './Dashboard/src/App.jsx';
import { useLocation } from 'react-router-dom';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import ProfilePatient from './Profile/profile-patient.tsx';
import ProfileDoctor from './Profile/profile-doctor.tsx';
import ProfileAdmin from './Profile/profile-admin.tsx';
import Profile from './Profile/Profile.tsx';
import SelectGame from './Components/Game/SelectGame.tsx';
import Sidebar from "./Dashboard/src/layout/Sidebar/Sidebar";
import DoctorListPage from './Dashboard/src/Admin/DoctorListPage.tsx'; 
import DoctorDetails from './Dashboard/src/Admin/DoctorDetails.tsx';
import AssignDoctor from "./Dashboard/src/Admin/AssignDoctor.tsx";
import PatientListPageContent from "./Dashboard/src/Admin/PatientListPage.tsx";
import Settings from "./settings.tsx";
function App() {

  const [open, setOpen] = React.useState(false);
  return (

    <Router>
{/*       
      <div style={{position:"absolute",top:10}}>
          <Navbar />
      </div> */}
  

      {/* <Header /> */}
      <Routes>
        <Route path="/Signin" element={<><div className="black"> <Navbar/> </div><Signin /></>} />
        <Route path="/Signup"  element={<><div className="black"> <Navbar/> </div><Signup /></>} />
        <Route path="/" element={<Front/>}/>
        <Route path='/Profile-Patient' element={<ProfilePatient/>}/>
        <Route path='/Profile-Admin' element={<ProfileAdmin/>}/>
        <Route path='/Profile-Doctor' element={<ProfileDoctor/>}/>
        <Route path='/game' element={<SelectGame/>}/>
        <Route path='/AssignDoctor' element={<><div className="black"><Navbar isLoggedIn={true}/></div><AssignDoctor/></>}/>
        <Route path='/DoctorDetails' element={<><div className="black"><Navbar isLoggedIn={true}/></div><DoctorDetails/></>} />
        <Route path='/DoctorsList' element={<><div className="black"><Navbar isLoggedIn={true}/></div><DoctorListPage/></>}/>
        <Route path='/PatientsList' element={<><div className="black"><Navbar isLoggedIn={true}/></div><PatientListPageContent/></>}/>
        <Route path='/Profile' element={<><div className="black"><Navbar isLoggedIn={true}/></div><Profile role={'Admin'}/></>}/>
        <Route path="/Dashboard" element={<><div className="black"><Navbar isLoggedIn={true}/></div><Dashboard role={'Admin'}/></>}/>
        <Route path="/Settings" element={<><div className="black"><Navbar isLoggedIn={true}/></div><Settings/></>}/>
      </Routes>
    </Router>

  );
}

export default App;
