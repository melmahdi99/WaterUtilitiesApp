import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import agent from '../Global/agent';
import type { WaterTreatmentPlant } from "../../types/watertreatmentplant";

export const useWaterTreatmentPlants = (id?: string) => {

    const queryClient = useQueryClient();

    const {data: waterTreatmentPlants, isPending} = useQuery({
        queryKey: ['waterTreatmentPlants'],
        queryFn: async () =>  {
            const response = await agent.get<WaterTreatmentPlant[]>('/waterTreatmentPlants');
            return response.data;
        }

        // staleTime: 1000 * 60 * 5
    });

    const {data: waterTreatmentPlant, isLoading: isLoadingWaterTreatmentPlant} = useQuery({
        queryKey: ['waterTreatmentPlants', id],
        queryFn: async () => {
            const response = await agent.get<WaterTreatmentPlant>(`/waterTreatmentPlants/${id}`);
            return response.data;
        },
        enabled: !!id
    });

    const updateWaterTreatmentPlant = useMutation({
        mutationFn: async (waterTreatmentPlant: WaterTreatmentPlant) => {
            await agent.put(`/waterTreatmentPlants/${waterTreatmentPlant.id}`, waterTreatmentPlant);
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['waterTreatmentPlants']
            })
        }
    });

    const createWaterTreatmentPlant = useMutation({
        mutationFn: async (waterTreatmentPlant: WaterTreatmentPlant) => {
            const response = await agent.post(`/waterTreatmentPlants/}`, waterTreatmentPlant);
            return response.data;
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['waterTreatmentPlants']
            })
        }
    });

    const deleteWaterTreatmentPlant = useMutation({
        mutationFn: async (id: string) => {
            await agent.delete(`/waterTreatmentPlants/${id}`);
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['waterTreatmentPlants']
            })
        }
    });

    return {
        waterTreatmentPlants,
        isPending,
        updateWaterTreatmentPlant,
        createWaterTreatmentPlant,
        deleteWaterTreatmentPlant,
        waterTreatmentPlant,
        isLoadingWaterTreatmentPlant
    }

}