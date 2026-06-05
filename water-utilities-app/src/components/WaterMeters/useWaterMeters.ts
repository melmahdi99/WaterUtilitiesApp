import { useQueryClient, useQuery, useMutation } from "@tanstack/react-query";
import type { WaterMeter } from "../../types/waterMeter";
import agent from "../Global/agent";

export const useWaterMeters = (id?: string) => {
    const queryClient = useQueryClient();

    const { data: waterMeters, isPending } = useQuery({
        queryKey: ['waterMeters'],
        queryFn: async () => {
            const response = await agent.get<WaterMeter[]>('/watermeters');
            return response.data;
        },
        enabled: !!id
    });

    const updateMeter = useMutation({
        mutationFn: async (meter: WaterMeter) => {
            await agent.put(`/watermeters/$(meter.id)`, meter);
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['waterMeters']
            })
        }
    });

    const createMeter = useMutation({
        mutationFn: async (meter: WaterMeter) => {
            const response = await agent.post('/watermeters/', meter);
                return response.data;
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['waterMeters']
            })
        }
    });

    const deleteMeter = useMutation({
        mutationFn: async (id: string) => {
            await agent.delete(`/waterMeters/${id}`);
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({
                queryKey: ['waterMeters']
            })
        }
    });

    return {
        waterMeters,
        isPending,
        updateMeter,
        createMeter,
        deleteMeter,
    }
}