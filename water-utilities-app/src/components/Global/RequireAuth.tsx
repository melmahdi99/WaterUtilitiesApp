import { Typography } from '@mui/material';
import { useLocation, Navigate, Outlet } from 'react-router';
import { useAccount } from './useAccount';

function RequireAuth() {

    const {currentUser, isLoadingUser} = useAccount();
    const location = useLocation();

    if(isLoadingUser) return <Typography>Loading...</Typography>

    if(!currentUser) return <Navigate to='/login' state={{from: location}}/>

    return (
      <Outlet/>
    )
}

export default RequireAuth