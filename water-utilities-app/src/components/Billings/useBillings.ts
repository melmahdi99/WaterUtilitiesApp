import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { Billing } from "../../types/billing";
import agent from "../Global/agent";
import { useLocation } from "react-router";


export const useBillings = (id?: string) => {
 
    const queryClient = useQueryClient();
    const location = useLocation();
 
    const { data: billings, isPending: billingsLoading } = useQuery({
    queryKey: ['billings'],
    queryFn: async () => {
      const response = await agent.get<Billing[]>('/billings');
      return response.data;
    },
    enabled: !id && location.pathname === '/billings'
  });
 
  const {data: billing, isLoading: isLoadingBilling} = useQuery({
    queryKey: ['billings', id],
    queryFn: async () => {
        const response = await agent.get<Billing>(`/billings/${id}`);
        return response.data;
    },
    enabled: !!id
  });
 
  const updateBilling = useMutation({
    mutationFn: async (billing: Billing) => {
        await agent.put(`/billings/${billing.id}`, billing);
    },
    onSuccess: async () => {
        await queryClient.invalidateQueries({
            queryKey: ['billings']
        })
    }
  });
 
  const createBilling = useMutation({
    mutationFn: async (billing: Billing) => {
        const response = await agent.post(`/billings/`, billing);
        return response.data;
    },
    onSuccess: async () => {
        await queryClient.invalidateQueries({
            queryKey: ['billings']
        })
    }
  });
 
  const deleteBilling = useMutation({
    mutationFn: async (id: string) => {
        await agent.delete(`/billings/${id}`);
    },
    onSuccess: async () => {
        await queryClient.invalidateQueries({
            queryKey: ['billings']
        })
    }
  });
 
  return {
    billings,
    billingsLoading,
    updateBilling,
    createBilling,
    deleteBilling,
    billing,
    isLoadingBilling
  }
}