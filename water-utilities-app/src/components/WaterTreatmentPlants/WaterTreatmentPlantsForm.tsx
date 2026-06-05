import { Button, Stack, TextField, Typography } from '@mui/material'
import React from 'react'
import type { WaterTreatmentPlant } from '../../types/watertreatmentplant';
import { useWaterTreatmentPlants } from './useWaterTreatmentPlants';
import { NavLink, useNavigate, useParams } from 'react-router';



function WaterTreatmentPlantsForm() {
    const navigate = useNavigate();
    const {id} = useParams();
    const {createWaterTreatmentPlant, updateWaterTreatmentPlant, waterTreatmentPlant, isLoadingWaterTreatmentPlant} = useWaterTreatmentPlants(id);

// export interface WaterTreatmentPlant{
//     id: string,
//     waterVolumeCapacity: number,
//     turbidity: number,
//     streetNum: number,
//     streetName: string,
//     streetSuffix: string,
//     zipCode: number,
//     kingdomName: string,
//     lat: number,
//     long: number
// }

    async function handleSubmit(event: React.SubmitEvent){
        event.preventDefault();

        const formData = new FormData(event.target);
        const data: Record<string, unknown> = {};
        formData.forEach((value, key) => {
            data[key] = value;
        });

        if(waterTreatmentPlant) {
            data.id = waterTreatmentPlant.id;
            //axios request to put the new version of the record
            await updateWaterTreatmentPlant.mutateAsync(data as unknown as WaterTreatmentPlant);
            navigate(`/waterTreatmentPlants/${waterTreatmentPlant.id}`);
        } else {
            //post endpoint here
            createWaterTreatmentPlant.mutate(data as unknown as WaterTreatmentPlant, {
                onSuccess: (waterTreatmentPlant) => {
                    navigate (`/waterTreatmentPlants/${waterTreatmentPlant.id}`);
                }
            });
        }
    }

    if(isLoadingWaterTreatmentPlant) return <Typography>Loading Water Treatment Plant...</Typography>


    // function handleChange(event: React.ChangeEvent<HTMLInputElement>){
    //     const {name, value} = event.target;
    //     setFormData((prev) => ({
    //         ...prev,
    //         [name]: value
    //     }));
    // }

    return (
        <Stack 
        component='form' 
        onSubmit={handleSubmit} 
        direction={'column'} 
        spacing={1}
        sx={{
            maxWidth: '400px',
            mx: 'auto',
            paddingTop: '50px'
        }}>
            <Typography variant='h5' sx={{display: 'flex', justifyContent:'center'}}>{waterTreatmentPlant ? 'Edit Water Treatment Plant' : 'Create Water Treatment Plant'}</Typography>

            <TextField 
            label="WaterVolumeCapacity" 
            name="waterVolumeCapacity" 
            defaultValue={waterTreatmentPlant?.waterVolumeCapacity} 
            />

            <TextField 
            label="Turbidity" 
            name="turbidity" 
            defaultValue={waterTreatmentPlant?.turbidity} 
            />

            <TextField 
            label="StreetNum" 
            name="streetNum" 
            defaultValue={waterTreatmentPlant?.streetNum} 
            />

            <TextField 
            label="StreetName" 
            name="streetName" 
            defaultValue={waterTreatmentPlant?.streetName} 
            />

            <TextField 
            label="StreetSuffix" 
            name="streetSuffix" 
            defaultValue={waterTreatmentPlant?.streetSuffix} 
            />
            
            <TextField 
            label="ZipCode" 
            name="zipCode" 
            defaultValue={waterTreatmentPlant?.zipCode} 
            />

            <TextField 
            label="KingdomName" 
            name="kingdomName" 
            defaultValue={waterTreatmentPlant?.kingdomName} 
            />
            
            <TextField label="Latitude" 
            name="latitude" 
            defaultValue={waterTreatmentPlant?.latitude} 
            />

            <TextField 
            label="Longitude" 
            name="longitude" 
            defaultValue={waterTreatmentPlant?.longitude} 
            />

            <Button type='submit' variant='contained'>Submit</Button>
            {waterTreatmentPlant && <Button component={NavLink} 
            to={`/waterTreatmentPlants/${waterTreatmentPlant.id}`}>Cancel</Button>}
        </Stack>
  )
}

export default WaterTreatmentPlantsForm