import { useNavigate } from "react-router";
import type { WaterMeter } from "../../types/waterMeter";
import { useWaterMeters } from './useWaterMeters.ts';
import { Button, Card, CardActions, CardContent, Chip, Typography } from "@mui/material";

type Props = {
    meter: WaterMeter;
}

function MeterCard({ meter }: Props) {
    const navigate = useNavigate();
    const { deleteMeter } = useWaterMeters();

    return (
        <Card>
            <CardContent>
                <Typography variant='h6'>Meter {meter.id.slice(0, 8)}...</Typography>
                <Typography variant='body2' color='text.secondary'>
                    Reading {meter.toFixed(3)} m³
                </Typography>
                <Typography variant='body2' color='text.secondary'>
                    Building: {meter.buildingId.slice(0, 8)}...
                </Typography>

                <Chip
                    label={meter.isOnline ? 'Online' : 'Offline'}
                    color={meter.isOnline ? 'success' : 'default'}
                    variant="outlined"
                    sx= {{ mt: 1 }}
                />
            </CardContent>

            <CardActions>
                <Button onClick={() => navigate(`/watermeters/${meter.id}`)}>View</Button>
                <Button onClick={() => deleteMeter.mutateAsync(meter.id)} color='error'>Delete</Button>
            </CardActions>
        </Card>
    )
}

export default MeterCard