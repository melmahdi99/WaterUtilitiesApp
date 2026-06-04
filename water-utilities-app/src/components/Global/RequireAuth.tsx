import { Typography } from '@mui/material';
import { useLocation, Navigate } from 'react-router';
import { useAccount } from './useAccount';

function RequireAuth() {

    const {currentUser, isLoadingUser} = useAccount();
    const location = useLocation();

    if(isLoadingUser) return <Typography>Loading...</Typography>

    if(!currentUser) return <Navigate to='/login' state={{from: location}}/>
  return (
    <div>RequireAuth</div>
  )
}

export default RequireAuth