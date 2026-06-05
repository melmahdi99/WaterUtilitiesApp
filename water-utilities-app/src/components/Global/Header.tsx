import { AppBar, Box, IconButton, List, ListItem, Toolbar, Typography, useTheme } from "@mui/material";
import { DarkMode, LightMode } from '@mui/icons-material'
import ListItemButtonLink from './ListItemButtonLink.tsx'
import { useAccount } from "./useAccount.ts";

type Props = {
    toggleDarkMode: () => void;
}

function Header({toggleDarkMode}:Props){

    const theme = useTheme();
    const {currentUser, role} = useAccount();
    
    return(
          <Box sx={{ flexGrow: 1}}>
            <AppBar position="static">
                <Toolbar>
                <IconButton
                    size="large"
                    edge="start"
                    color="inherit"
                    aria-label="menu"
                    sx={{ mr : 2 }}
                    onClick={toggleDarkMode}
                >
                    {theme.palette.mode === 'dark' ?
                    <LightMode/> : <DarkMode/>}
                </IconButton>
                <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                    Water Utilities App
                </Typography>
                <List sx={{display:'flex', flexDirection:'row'}}>
                    <ListItem>
                        <ListItemButtonLink to={`/`}>Home</ListItemButtonLink>
                    </ListItem>
                    <ListItem>
                        <ListItemButtonLink to={`/waterTreatmentPlants`}>Water Treatment Plants</ListItemButtonLink>
                    </ListItem>
                    <ListItem>
                        <ListItemButtonLink to={`/buildings`}>Buildings</ListItemButtonLink>
                    </ListItem>
                    <ListItem>
                        <ListItemButtonLink to={`/watermeters`}>Water Meters</ListItemButtonLink>
                    </ListItem>
                    <ListItem>
                        <ListItemButtonLink to={`/customers`}>Customers</ListItemButtonLink>
                    </ListItem>
                    <ListItem>
                        <ListItemButtonLink to={`/billings`}>Billings</ListItemButtonLink>
                    </ListItem>
                    <ListItem>
                        {currentUser ? <ListItemButtonLink to={`/accounts/user-info`}>Account</ListItemButtonLink>
                        : <ListItemButtonLink to={`/login`}>Login</ListItemButtonLink>}
                    </ListItem>
                    <ListItem>
                        {role === 'Admin' && currentUser && <ListItemButtonLink to={`/createWaterTreatmentPlant`}>Create a Water Treatment Plant</ListItemButtonLink> }
                    </ListItem>
                </List>
                </Toolbar>
            </AppBar>
        </Box>
    )
}

export default Header