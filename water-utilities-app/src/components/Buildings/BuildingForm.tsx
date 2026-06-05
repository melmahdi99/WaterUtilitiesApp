import { Button, MenuItem, Stack, TextField, Typography } from '@mui/material';
import React from 'react';
import { NavLink, useNavigate, useParams } from 'react-router';
import { useBuildings } from './useBuildings.ts';
import type { Building, CreateBuildingDto } from '../../types/building';


const kingdoms = ['Ethonia', 'Southport', 'Westhold', 'Northreach'];


function BuildingForm() {


    const navigate = useNavigate();
    const { id } = useParams();
    const { createBuilding, updateBuilding, building, isLoadingBuilding } = useBuildings(id);


    async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();


        const formData = new FormData(event.currentTarget);
        const data: Record<string, unknown> = {};
        formData.forEach((value, key) => {
            data[key] = value;
        });


        if (building) {
            data.id = building.id;
            await updateBuilding.mutateAsync(data as unknown as Building);
            navigate(`/buildings/${building.id}`);
        } else {
            createBuilding.mutate(data as unknown as CreateBuildingDto, {
                onSuccess: (created) => {
                    navigate(`/buildings/${created.id}`);
                }
            });
        }
    }


    if (isLoadingBuilding) return <Typography>Loading building...</Typography>;


    return (
        <Stack
            component='form'
            onSubmit={handleSubmit}
            direction='column'
            spacing={1}
            sx={{ maxWidth: 500, m: 3 }}
        >
            <Typography variant='h5'>{building ? 'Edit Building' : 'Create Building'}</Typography>


            <TextField
                label='Building Type'
                name='buildingType'
                defaultValue={building?.buildingType}
            />


            <TextField
                label='Street Number'
                name='streetNum'
                type='number'
                defaultValue={building?.streetNum}
            />


            <TextField
                label='Street Name'
                name='streetName'
                defaultValue={building?.streetName}
            />


            <TextField
                label='Street Suffix'
                name='streetSuffix'
                defaultValue={building?.streetSuffix}
            />


            <TextField
                label='Zip Code'
                name='zipCode'
                type='number'
                defaultValue={building?.zipCode}
            />


            <TextField
                select
                label='Kingdom'
                name='kingdomName'
                defaultValue={building?.kingdomName ?? ''}
            >
                {kingdoms.map(k => (
                    <MenuItem key={k} value={k}>{k}</MenuItem>
                ))}
            </TextField>


            <Button type='submit' variant='contained'>Submit</Button>
            {building && (
                <Button component={NavLink} to={`/buildings/${building.id}`}>Cancel</Button>
            )}
        </Stack>
    );
}

export default BuildingForm;