import React from 'react'
import { useAccount } from './useAccount'
import { Box, Paper, Typography } from '@mui/material';

function UserInfo() {
    const { currentUser, isLoadingUser} = useAccount();

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
        </Box>
        </Paper>
    );
}

export default UserInfo