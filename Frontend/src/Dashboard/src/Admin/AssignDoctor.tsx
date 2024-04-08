import * as React from 'react';
import Autocomplete from '@mui/joy/Autocomplete';
import AutocompleteOption from '@mui/joy/AutocompleteOption';
import Stack from '@mui/joy/Stack';
import Sidebar from '../layout/Sidebar/Sidebar';
import Typography from '@mui/joy/Typography';
import Button  from '@mui/joy/Button';

import { useLocation } from 'react-router-dom';
import Snackbar from '@mui/joy/Snackbar';
import PlaylistAddCheckCircleRoundedIcon from '@mui/icons-material/PlaylistAddCheckCircleRounded';
const options = ['Habiba Mohamed', 'Mina Antoun','Medhat','Shaden'];




export default function AssignDoctor() {
  const [open, setOpen] = React.useState(false);
  const [value, setValue] = React.useState<string | null>(options[0]);
  const [inputValue, setInputValue] = React.useState('');
  const location = useLocation();
  const recieved = location.state;
  console.log(recieved.receivedObject.doctor.DoctorName)
  return (
    <div className="app profile">
    <Sidebar role={'Admin'} />

    <div>
  <div className="subgrid-two-item grid-common grid-c7 scroll" style={{position:'relative',margin:'30vh',height:'auto',width:'100%'}}>
        <div className="grid-c-title">
            <h3 className="grid-c-title-text" >Select A Patient</h3>
           
        </div>
        <Typography level="body-sm" sx={{ mb: 1 }}>
        <code>value: </code>
        <Typography variant="soft" sx={{ py: 0.4 }}>
          <code>
            <strong>{`${value !== null ? `'${value}'` : 'null'}`}</strong>
          </code>
        </Typography>
      </Typography>
      <Typography level="body-sm">
        <code>inputValue: </code>
        <Typography variant="soft" sx={{ py: 0.4 }}>
          <code>
            <strong>{`'${inputValue}'`}</strong>
          </code>
        </Typography>
      </Typography>
      <br />
  
      <Autocomplete
        variant="soft"
        placeholder="Soft variant"
        options={options}
        sx={{ width: 300 }}
        value={value}
        onChange={(event, newValue) => {
          setValue(newValue);
        }}
        inputValue={inputValue}
        onInputChange={(event, newInputValue) => {
          setInputValue(newInputValue);
        }}
        
      />
   
   <Button  onClick={()=>setOpen(true)} sx={{marginTop:'10px'}} color="success">
     Assign to  {recieved.receivedObject.doctor.DoctorName}
      </Button>
    </div>
  
    </div>
   
    
    <Snackbar
        variant="soft"
        color="success"
        open={open}
        onClose={() => setOpen(false)}
        anchorOrigin={{ vertical: 'bottom', horizontal: 'center' }}
        startDecorator={<PlaylistAddCheckCircleRoundedIcon />}
        endDecorator={
          <Button
            onClick={() => setOpen(false)}
            size="sm"
            variant="soft"
            color="success"
          >
            Dismiss
          </Button>
        }
      >
      Assigned The Patient
      </Snackbar>
    </div>
    
    
   
     
  );
}