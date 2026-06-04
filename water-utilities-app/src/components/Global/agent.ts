import axios from "axios";

const agent = axios.create({
    //Base url from main branch, can change your settings in launchsettings.json to
    //also use this port for consistency.
    baseURL: 'https://localhost:7017/api',
    withCredentials: true
});

agent.interceptors.response.use(async (response) => {
    try{
        return response;
    } catch (err) {
        console.error(err);
        return Promise.reject(err);
    }
});

export default agent;