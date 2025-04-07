import { WeatherEntry } from '../types/WeatherEntry';

const API_BASE_URL = process.env.REACT_APP_API_BASE_URL;

export const fetchWeatherData = async (city: string): Promise<WeatherEntry[]> => {
    const response = await fetch(`${API_BASE_URL}/weather/${encodeURIComponent(city)}`);
    if (!response.ok) throw new Error(`Failed to fetch weather for ${city}`);
    return await response.json();
};
