import type { Billing } from '../../types/billing';
import { Button, Card, CardActions, CardContent, Typography} from '@mui/material';
import { useBillings } from './useBillings';
import { useNavigate } from 'react-router';

type Props = {
    billing: Billing;
}

function BillingCard({billing} : Props) {

    const navigate = useNavigate()
    const {deleteBilling} = useBillings();

    return (
    <Card>
        <CardContent>
            <Typography>{billing.id}</Typography>
        </CardContent>
        <CardActions>
            <Button onClick={() => navigate(`/billings/${billing.id}`)}>View</Button>
            <Button onClick={() => deleteBilling.mutateAsync(billing.id)} color='error'>Delete</Button>
        </CardActions>
    </Card>
  )
}

export default BillingCard
