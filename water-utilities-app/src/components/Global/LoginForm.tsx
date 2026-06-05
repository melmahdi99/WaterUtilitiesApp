import React from 'react';
import type { LoginCreds } from '../../types';
import { Box, Button, Paper, TextField, Typography } from '@mui/material';
import { LockOpen } from '@mui/icons-material';
import { useLocation, useNavigate} from 'react-router'
import { useAccount } from './useAccount';
import { blue } from '@mui/material/colors';

function LoginForm() {
    const {loginUser} = useAccount();
    const navigate = useNavigate();
    const location = useLocation();

    async function onSubmit(event:React.SubmitEvent) {

        event.preventDefault();
        const formData = new FormData(event.target);
        const data: Record<string, unknown> = {};
        formData.forEach((value, key) => {
            data[key] = value;
        });

        //Subject to change, its currently defaulting to showing user info on login
        await loginUser.mutateAsync(data as unknown as LoginCreds, {
            onSuccess: () => {
                navigate(location.state?.from || '/accounts/user-info')
            }
        });
        
    }

  return (
    <Box sx={{display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '80vh'
    }}
    >
        <Paper 
            component='form' 
            onSubmit={onSubmit}
            elevation={3}
            sx={{
                padding: 4,
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                gap: 2,
                maxWidth: '25vw',
                width: '100%',
                backgroundColor: 'transparent'
            }}
        >
            <Box sx={{display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                mb: 1,
                backgroundColor: 'transparent'
            }}
            >
                <LockOpen/>
                <Typography variant='h4'>Sign In</Typography>
            </Box>
            <TextField label="Email" name="email" sx={{maxWidth: '17vw', width:'100%'}}/>
            <TextField label="Password" name="password" type='password' sx={{maxWidth: '17vw', width:'100%'}}/>
            <Button type='submit' variant='contained'>Login</Button>
        </Paper>
    </Box>
    
  )
}

export default LoginForm