import React from "react";
import '../../App.css';
import Button from '@mui/material/Button';
import './SelectGame.css';
import Alert from '@mui/material/Alert';
import Stack from '@mui/material/Stack';

export default function SelectGame() {
    const [open,SetOpen]=React.useState(false);
    return (
        <Stack sx={{ width: '100%' }} spacing={2} className="center">
     
            <Button onClick={()=>SetOpen(true)} variant='outlined' sx={{ '&:hover': { backgroundColor: 'rgb(33,150,243)', color:"#ffff" , transition:'background-color 0.4s linear'} }}>Start Game</Button>
            
            <Alert  severity="info" style={{display:open?"":'none'}}>Please make sure to connect your headset</Alert>
      
     
        </Stack>


    );
}
