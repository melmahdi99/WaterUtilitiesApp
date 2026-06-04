import React from 'react';
import { loginCreds } from '../../types';
import { Box, Button, Paper, TextField, Typography } from '@mui/material';
import { LockOpen } from '@mui/icons-material';
import { useLocation, useNavigate} from 'react-router'

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
    <Paper component='form' onSubmit={onSubmit}>
        <Box>
            <LockOpen/>
            <Typography variant='h4'>Sign In</Typography>
        </Box>
        <TextField label="Email" name="email"/>
        <TextField label="Password" name="password" type='password'/>
        <Button type='submit' variant='contained'>Login</Button>
    </Paper>
  )
}

export default LoginForm