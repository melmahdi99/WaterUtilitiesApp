import { Button, Card, CardActions, CardContent, CardMedia, Typography } from '@mui/material';
import { useCustomer } from './useCustomer';
import { NavLink, useNavigate, useParams } from 'react-router';


function CustomerDetails() {

    const navigate = useNavigate();
    const {id} = useParams();
    const {customer} = useCustomer(id);


  return (
    <Card>
        {/* <CardMedia
        component='img'
        src={`/images/${customer?.id}.png`}
        /> */}

        <CardMedia
        component='img'
        src={`/images/Test.png`}
        />
        <CardContent>
            <Typography variant='h4'>{customer?.firstName} {customer?.lastName}</Typography>
            <Typography variant='subtitle1'>ID: {customer?.id}</Typography>
        </CardContent>
        <CardActions>
            <Button component={NavLink} to={`/customers/manage/${id}`} color="primary">Edit</Button>
            <Button onClick={() => navigate('/customers')}>Cancel</Button>
        </CardActions>
    </Card>
  )
}

export default CustomerDetails