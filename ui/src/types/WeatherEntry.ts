export interface WeatherEntry {
    city: string;
    country: string;
    temperature: number;
    updatedAt: string; // lub Date, jeśli parsujesz od razu
}
