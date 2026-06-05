import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { Customer} from "../../types/Customer";
import agent from "../Global/agent";


export const useCustomer = (id?: string) => {

    const queryClient = useQueryClient();

    const { data: customers, isPending } = useQuery({
    queryKey: ['customers'],
    queryFn: async () => {
      const response = await agent.get<Customer[]>('/customers');
      return response.data;
    }
  });

  const {data: customer, isLoading: isLoadingCustomer} = useQuery({
    queryKey: ['customers', id],
    queryFn: async () => {
        const response = await agent.get<Customer>(`/customers/${id}`);
        return response.data;
    },
    enabled: !!id
  });

  const updateCustomer = useMutation({
    mutationFn: async (customer: Customer) => {
        await agent.put(`/customers/${customer.id}`, customer);
    },
    onSuccess: async () => {
        await queryClient.invalidateQueries({
            queryKey: ['customers']
        })
    }
  });

  const createCustomer = useMutation({
    mutationFn: async (customer: Customer) => {
        const response = await agent.post(`/customers/`, customer);
        return response.data;
    },
    onSuccess: async () => {
        await queryClient.invalidateQueries({
            queryKey: ['customers']
        })
    }
  });

  const deleteCustomer = useMutation({
    mutationFn: async (id: string) => {
        await agent.delete(`/customers/${id}`);
    },
    onSuccess: async () => {
        await queryClient.invalidateQueries({
            queryKey: ['customers']
        })
    }
  });

  return {
    customers,
    isPending,
    updateCustomer,
    createCustomer,
    deleteCustomer,
    customer,
    isLoadingCustomer
  }
} 