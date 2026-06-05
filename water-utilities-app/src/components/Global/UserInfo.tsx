import React from 'react'
import { useAccount } from './useAccount'
import { Box, Button, Paper, Typography } from '@mui/material';
import { logout } from './agent';
import { useNavigate } from 'react-router';
import { useQueryClient } from '@tanstack/react-query';

function UserInfo() {
    const { currentUser, isLoadingUser} = useAccount();
    const navigate = useNavigate();
    const queryClient = useQueryClient();

    if(isLoadingUser) {
        return <Box></Box>
    }

    if(!currentUser){
        return(
            <Box sx={{ p: 2 }}>
            <Typography color="error">No user session found. Please sign in.</Typography>
            </Box>
        )
    }

    const handleLogout = async () => {
        try {
            await logout();
            // queryClient.invalidateQueries({ queryKey: ['user'] });
            // navigate('/')
            window.location.href = '/';
        } catch (err) {
            alert("Failed to logout");
        }
        console.log("Logged out successfully");
    };
    
    return (
        <Paper elevation={2} sx={{ p: 3, maxWidth: 400, margin: '20px auto' }}>
        <Typography variant="h5">
            Account Information
        </Typography>
        
        <Box sx={{ display: 'flex', flexDirection: 'column', gap: 1, mt: 2 }}>
            <Typography><strong>Email:</strong> {currentUser.email}</Typography>
            <Typography><strong>First Name:</strong> {currentUser.firstName}</Typography>
            <Typography><strong>Last Name:</strong> {currentUser.lastName}</Typography>
            <Typography><strong>System Role:</strong> {currentUser.role}</Typography>
            <Button variant='outlined' onClick={handleLogout} >Logout</Button>
        </Box>
        </Paper>
    );
}

export default UserInfo