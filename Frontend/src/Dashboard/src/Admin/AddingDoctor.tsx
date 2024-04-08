import { useEffect } from 'react';
import * as React from 'react';
import Card from '@mui/joy/Card';
import CardActions from '@mui/joy/CardActions';
import CardContent from '@mui/joy/CardContent';
import Checkbox from '@mui/joy/Checkbox';
import Divider from '@mui/joy/Divider';
import FormControl from '@mui/joy/FormControl';
import FormLabel from '@mui/joy/FormLabel';
import Input from '@mui/joy/Input';
import Typography from '@mui/joy/Typography';
import Button from '@mui/joy/Button';
import InfoOutlined from '@mui/icons-material/InfoOutlined';
import CreditCardIcon from '@mui/icons-material/CreditCard';
import Snackbar from '@mui/joy/Snackbar';
import PlaylistAddCheckCircleRoundedIcon from '@mui/icons-material/PlaylistAddCheckCircleRounded';
import { Alert } from '@mui/material';
import Stack from '@mui/material/Stack';
export default function AddDoctor() {
    const [open, setOpen] = React.useState(false);

    useEffect(() => {
        const timeout = setTimeout(() => {
          setOpen(false); // Set open to false after 5 seconds
        }, 5000);
    
        // Clear the timeout if component unmounts or open changes
        return () => clearTimeout(timeout);
      }, [open]);
  return (
    <Card
      variant="outlined"
      sx={{
        maxHeight: 'max-content',
        maxWidth: '100%',
        mx: 'auto',
        // to make the demo resizable
        overflow: 'auto',
        resize: 'horizontal',
      }}
    >
      <Typography level="title-lg" startDecorator={<InfoOutlined />}>
        Add New Doctor
      </Typography>
      <Divider inset="none" />
      <CardContent
        sx={{
          display: 'grid',
          gridTemplateColumns: 'repeat(2, minmax(80px, 1fr))',
          gap: 1.5,
        }}
      >
        <FormControl sx={{ gridColumn: '1/-1' }}>
          <FormLabel>Doctor Name</FormLabel>
          <Input/>
        </FormControl>
        <FormControl>
          <FormLabel>Phone Number</FormLabel>
          <Input  />
        </FormControl>
        <FormControl>
          <FormLabel>Email</FormLabel>
          <Input />
        </FormControl>
       
      
        <CardActions sx={{ gridColumn: '1/-1' }}>
        <Stack sx={{ width: '100%' }} spacing={2}>
     
          <Button variant="solid" color="primary"  onClick={()=>setOpen(true)}>
            Add Doctor
          </Button>
          <Alert  severity="success" style={{display:open?"":'none'}}  onClose={() => setOpen(false)}>Added Doctor</Alert>
          </Stack>
        </CardActions>
      </CardContent>
  
    </Card>

 

    
  );
}