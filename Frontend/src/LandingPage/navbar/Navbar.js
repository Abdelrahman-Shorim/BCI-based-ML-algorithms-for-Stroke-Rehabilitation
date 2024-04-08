import React from 'react';
import { Link } from 'react-router-dom';
import './navbar.css';
import logo from '../../logo.svg';
import Dropdown from '@mui/joy/Dropdown';
import Menu from '@mui/joy/Menu';
import MenuButton from '@mui/joy/MenuButton';
import MenuItem from '@mui/joy/MenuItem';
import HelpRoundedIcon from '@mui/icons-material/HelpRounded';
import OpenInNewRoundedIcon from '@mui/icons-material/OpenInNewRounded';
import LogoutRoundedIcon from '@mui/icons-material/LogoutRounded';
import ListDivider from '@mui/joy/ListDivider';
import Box from '@mui/joy/Box';
import Typography from '@mui/joy/Typography';
import SettingsRoundedIcon from '@mui/icons-material/SettingsRounded';
import Avatar from '@mui/joy/Avatar';
import { personsImgs } from '../../Dashboard/src/utils/images';
import { ThemeProvider, createTheme } from '@mui/material/styles';
import { CssVarsProvider } from '@mui/joy';
const Navbar = ({ isLoggedIn }) => {
  const theme= createTheme({
    palette:{
      mode:'dark',
    }
  });
  if (!isLoggedIn) {
    return (
      
      <div className="gpt3__navbar">
        <div className="gpt3__navbar-links">
          <div className="gpt3__navbar-links_container">
            <Link to="/">
              <p>
                <a href="#home">MindMend</a>
              </p>
            </Link>
          </div>
          <div className="gpt3__navbar-links_container">
            <Link to="/">
              <p>
                <a>Home</a>
              </p>
            </Link>
            <p>
              <a href="#sec2">What is MindMend?</a>
            </p>
            <p>
              <a href="#blog">Our Therapy</a>
            </p>
          </div>
        </div>
        <div className="gpt3__navbar-sign">
          <Link to="/Signin">
            <button className="btn" type="button">
              Sign in
            </button>
          </Link>
          <Link to="/Signup">
            <button type="button">Sign up</button>
          </Link>
        </div>
        <div className="gpt3__navbar-menu">
          {/* Add menu items here */}
        </div>
      </div>
    );
  } else {
    return (
      <CssVarsProvider defaultMode="dark" disableTransitionOnChange>
      <div className="gpt3__navbar">
        <div className="gpt3__navbar-links">
          <div className="gpt3__navbar-links_container">
            <Link to="/">
              <p>
                <a href="#home">MindMend</a>
              </p>
            </Link>
          </div>
          <div className="gpt3__navbar-links_container">
            <Link to="/">
              <p>
                <a>Home</a>
              </p>
            </Link>
            <p>
              <a href="#sec2">What is MindMend?</a>
            </p>
            <p>
              <a href="#blog">Our Therapy</a>
            </p>
          </div>
          <div style={{ display: 'flex', justifyContent: 'flex-end' }} className='dropdown-wrapper'>
        
          <Dropdown>
          <MenuButton
            variant="plain"
            size="sm"
            sx={{ maxWidth: '32px', maxHeight: '32px', borderRadius: '9999999px' ,backgroundColor:'transparent'}}
          >
            <Avatar
              src={personsImgs.person_two}
             
              sx={{ maxWidth: '32px', maxHeight: '32px' ,}}
            />
          </MenuButton>
          <Menu
            placement="bottom-end"
            size="sm"
            sx={{
              zIndex: '99999',
              p: 1,
              gap: 1,
              '--ListItem-radius': 'var(--joy-radius-sm)',
              
            }}
          >
            <MenuItem>
              <Box
                sx={{
                  display: 'flex',
                  alignItems: 'center',
                }}
              >
                <Avatar
                src={personsImgs.person_two}
                  sx={{ borderRadius: '50%' }}
                />
                <Box sx={{ ml: 1.5 }}>
                  <Typography level="title-sm" textColor="text.primary">
                    Habiba Mohamed
                  </Typography>
                  <Typography level="body-xs" textColor="text.tertiary">
                   Habiba@gmail.com
                  </Typography>
                </Box>
              </Box>
            </MenuItem>
            <ListDivider />
            <MenuItem>
              <HelpRoundedIcon />
              Help
            </MenuItem>
            <MenuItem>
              <SettingsRoundedIcon />
              Settings
            </MenuItem>
            <ListDivider />
            <MenuItem component="a" href="/blog/first-look-at-joy/">
              Contact Us
              <OpenInNewRoundedIcon />
            </MenuItem>
            <MenuItem
              component="a"
              href="https://github.com/mui/material-ui/tree/master/docs/data/joy/getting-started/templates/email"
            >
              Instructions
              <OpenInNewRoundedIcon />
            </MenuItem>
            <ListDivider />
            <MenuItem>
              <LogoutRoundedIcon />
              Log out
            </MenuItem>
          </Menu>
        </Dropdown>
        
          
        </div>
        </div>
        <div className="gpt3__navbar-menu">
          {/* Add menu items here */}
        </div>
      </div>
      </CssVarsProvider>
    );
    
  }
};

export default Navbar;
