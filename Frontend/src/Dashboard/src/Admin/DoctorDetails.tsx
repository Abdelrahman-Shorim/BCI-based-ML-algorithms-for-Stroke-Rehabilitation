import React from "react"
import { useLocation, useNavigate } from 'react-router-dom';
import Sidebar from "../layout/Sidebar/Sidebar";
import Stack from '@mui/joy/Stack';
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import EmailRoundedIcon from '@mui/icons-material/EmailRounded';
import IconButton from '@mui/joy/IconButton';
import Button from '@mui/material/Button';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { purple } from '@mui/material/colors';
import './DoctorList.css';


export default function DoctorDetails() {
    const navigate=useNavigate();
    const location = useLocation();
    const receivedObject = location.state;
    console.log(receivedObject);

    
    const handleClick = () => {
      console.log('Assigning Doctor...'+receivedObject.doctor.DoctorName);
      // Navigate to DoctorDetails page and pass rowData as state
      navigate('/AssignDoctor', { state: { receivedObject } });
    };
  
    return (
        <div className="app profile">
        <Sidebar role={'Admin'} />
    
 
      <div className="grid-one-item grid-common grid-c2 " style={{position:'relative',margin:'10vh',height:'auto',width:'100%'}}>
        

        <div className="grid-content ">
          <div className="grid-items">
            {
              <div className="grid-item">
                <div className="grid-item-l">
                <div className="PersonalInfo">
                <div className="ImgeandTitle">
                  <div className="avatar img-fit-cover"  style={{ width: '150px', height: '150px' ,maxHeight:'150px',maxWidth:'150px'}}>
                    <img  src="https://images.unsplash.com/photo-1535713875002-d1d0cf377fde?auto=format&fit=crop&w=286"  alt="" />
                  
                  </div>
                  <h1 style={{marginLeft:'2rem'}}>{receivedObject.doctor.DoctorName}</h1>
                 
                  </div>
                  <br />
                    <Stack spacing={2} sx={{ flexGrow: 1 }}>
              <Stack spacing={1}>
                <FormLabel>Personal Info</FormLabel>
                <FormControl
                  sx={{ display: { sm: 'flex-column', md: 'flex-row' }, gap: 2 }}
                >
                 <div style={{display:'flex'}}>
                  <Input size="sm" placeholder="First name" defaultValue={receivedObject.doctor.DoctorName} />
                  <Input size="sm" placeholder="Last name" sx={{ flexGrow: 1 , marginLeft:'10px'}}  />
                  </div>
                  <Input size="sm" placeholder="Phone Number" sx={{ flexGrow: 1 }}  defaultValue={receivedObject.doctor.PhoneNumber}/>
                </FormControl>
              </Stack>
              <Stack direction="row" spacing={2}>
                <FormControl>
                  <FormLabel>Role</FormLabel>
                  <Input size="sm" defaultValue="Doctor" disabled />
                </FormControl>
                
                <FormControl sx={{ flexGrow: 1 }}>
                  <FormLabel>Email</FormLabel>
                  <Input
                    size="sm"
                    type="email"
                    startDecorator={<EmailRoundedIcon />}
                    placeholder="email"
                    defaultValue={receivedObject.doctor.Email}
                    sx={{ flexGrow: 1 }}
                  />
                </FormControl>


              </Stack>
              <br />
              <Stack direction="row" spacing={2}>
      <Button variant="outlined"  color="error" startIcon={<DeleteIcon  sx={{ color: purple[50] }}/>} >
        Delete
      </Button>
      <Button variant="contained" endIcon={<EditIcon  sx={{ color: purple[50] }} />}>
       Edit
      </Button>
    </Stack>
             
            </Stack>
            </div>
            </div>



            <div style={{display:'grid',gridColumn:'1'}}>
            <div className="subgrid-two-item grid-common grid-c7 scroll">
        <div className="grid-c-title">
            <h3 className="grid-c-title-text">Pateints List</h3>
          
        </div>
        <div className="grid-c7-content" style={{position:'relative' , display:'grid' , paddingTop:'40px', gap: '25px',width:'100%'}}>
          <ul>Habiba Mohamed Abdelrhman Salem  
           <Button variant="outlined"  color="error" sx={{marginLeft:'10px'}} startIcon={<DeleteIcon  sx={{  color: purple[50] }}/>} >
             Delete
           </Button>
           
     </ul> 
          <ul>Habiba Mohamed 
          <Button variant="outlined"  color="error" sx={{marginLeft:'10px'}} startIcon={<DeleteIcon  sx={{  color: purple[50] }}/>} >
             Delete
           </Button>
          </ul>
          <ul>Habiba Mohamed
          <Button variant="outlined"  color="error" sx={{marginLeft:'10px'}} startIcon={<DeleteIcon  sx={{  color: purple[50] }}/>} >
             Delete
           </Button>
          </ul>
          <ul>Habiba Mohamed
          <Button variant="outlined"  color="error" sx={{marginLeft:'10px'}} startIcon={<DeleteIcon  sx={{  color: purple[50] }}/>} >
             Delete
           </Button>
          </ul>
          <ul>Habiba Mohamed
          <Button variant="outlined"  color="error" sx={{marginLeft:'10px'}} startIcon={<DeleteIcon  sx={{  color: purple[50] }}/>} >
             Delete
           </Button>
          </ul>
          <ul>Habiba Mohamed
          <Button variant="outlined"  color="error" sx={{marginLeft:'10px'}} startIcon={<DeleteIcon  sx={{  color: purple[50] }}/>} >
             Delete
           </Button>
          </ul>
        
    </div>
   
    </div>
   
    <Button onClick={()=>handleClick()} variant="contained" sx={{marginTop:'10px'}} color="success">
        Add
      </Button>
          
         </div>
         </div>
        }   
        
          </div>
                </div>
           

      </div>
      
 
      </div>
      );
  
        }

