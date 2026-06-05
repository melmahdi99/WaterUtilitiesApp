import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import agent from "../Global/agent";
import type { Building, CreateBuildingDto } from '../../types/building';




export const useBuildings = (id?: string) => {


    const queryClient = useQueryClient();


    const { data: buildings, isPending } = useQuery({
        queryKey: ['buildings'],
        queryFn: async () => {
            const response = await agent.get<Building[]>('/buildings');
            return response.data;
        },
        staleTime: 1000 * 60 * 5
    });


    const { data: building, isLoading: isLoadingBuilding } = useQuery({
        queryKey: ['buildings', id],
        queryFn: async () => {
            const response = await agent.get<Building>(`/buildings/${id}`);
            return response.data;
        },
        enabled: !!id
    });


    const createBuilding = useMutation({
        mutationFn: async (dto: CreateBuildingDto) => {
            const response = await agent.post<Building>('/buildings/', dto);
            return response.data;
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({ queryKey: ['buildings'] });
        }
    });


    const updateBuilding = useMutation({
        mutationFn: async (building: Building) => {
            await agent.put(`/buildings/${building.id}`, building);
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({ queryKey: ['buildings'] });
        }
    });


    const deleteBuilding = useMutation({
        mutationFn: async (id: string) => {
            await agent.delete(`/buildings/${id}`);
        },
        onSuccess: async () => {
            await queryClient.invalidateQueries({ queryKey: ['buildings'] });
        }
    });


    return {
        buildings,
        isPending,
        building,
        isLoadingBuilding,
        createBuilding,
        updateBuilding,
        deleteBuilding
    };
};