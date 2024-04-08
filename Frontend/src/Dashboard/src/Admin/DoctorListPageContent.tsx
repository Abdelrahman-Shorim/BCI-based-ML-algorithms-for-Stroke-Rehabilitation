import * as React from 'react';
import SwipeableViews from "react-swipeable-views-react-18-fix";
import { useTheme } from '@mui/material/styles';
import AppBar from '@mui/material/AppBar';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import DoctorListView from './DoctorListView.tsx';
import AddDoctor from './AddingDoctor.tsx';
import AssignDoctor from './AssignDoctor.tsx';
import PlaylistAddCheckCircleRoundedIcon from '@mui/icons-material/PlaylistAddCheckCircleRounded';
import Button from '@mui/joy/Button';



interface TabPanelProps {
  children?: React.ReactNode;
  dir?: string;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;
  
  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      style={{backgroundColor:'rgb(4,12,24)',height:'100%'}}
      id={`full-width-tabpanel-${index}`}
      aria-labelledby={`full-width-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `full-width-tab-${index}`,
    'aria-controls': `full-width-tabpanel-${index}`,
  };
}

export default function DoctorListPageContent() {
  const theme = useTheme();
  const [value, setValue] = React.useState(0);
  const [open, setOpen] = React.useState(false);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  const handleChangeIndex = (index: number) => {
    setValue(index);
  };

  return (
    
    <Box sx={{ width: '100%' ,height:'auto' ,backgroundColor:'rgb(4,12,24)'}}>
      <AppBar position="static" sx={{backgroundColor:'#232933'}}>
        <Tabs
          value={value}
          onChange={handleChange}
     
          textColor="inherit"
          variant="fullWidth"
          aria-label="full width tabs example"
        >
          <Tab label="Doctors List" {...a11yProps(0)} />
          <Tab label="Add Doctor" {...a11yProps(1)} />
        
        </Tabs>
      </AppBar>
      <SwipeableViews 
    
        axis={theme.direction === 'rtl' ? 'x-reverse' : 'x'}
        index={value}
        onChangeIndex={handleChangeIndex}
      >
        <TabPanel value={value} index={0} dir={theme.direction}>
        <DoctorListView/>
        </TabPanel>
        <TabPanel value={value} index={1} dir={theme.direction}>
        <AddDoctor/>
   
        </TabPanel>
       
      </SwipeableViews>
    </Box>
  );
}