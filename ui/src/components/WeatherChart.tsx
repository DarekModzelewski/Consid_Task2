import React, { useEffect, useState } from 'react';
import { fetchWeatherData } from '../api/weather';

import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
} from 'chart.js';
import { Line } from 'react-chartjs-2';

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
);

const cities = [
    'London',
    'Manchester',
    'Berlin',
    'Munich',
    'Paris',
    'Arrondissement de Lyon'
];

const getRandomColor = () =>
    `hsl(${Math.floor(Math.random() * 360)}, 70%, 50%)`;

export const WeatherChart = () => {
    const [chartData, setChartData] = useState<any>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadWeather = async () => {
            try {
                const allData = await Promise.all(
                    cities.map(async city => {
                        const data = await fetchWeatherData(city);
                        return { city, data };
                    })
                );

                const labels = allData[0].data.map(d =>
                    new Date(d.updatedAt).toLocaleTimeString([], {
                        hour: '2-digit',
                        minute: '2-digit'
                    })
                );

                const datasets = allData.map(({ city, data }) => ({
                    label: city,
                    data: data.map(d => d.temperature),
                    borderColor: getRandomColor(),
                    backgroundColor: 'rgba(0, 0, 0, 0.1)',
                    tension: 0.3
                }));

                setChartData({ labels, datasets });
            } catch (error) {
                console.error(error);
            } finally {
                setLoading(false);
            }
        };

        loadWeather();
    }, []);

    const options = {
        responsive: true,
        plugins: {
            legend: { position: 'top' as const },
            title: { display: true, text: 'Temperature Trend by City' }
        }
    };

    if (loading) return <p>Loading weather data...</p>;
    if (!chartData) return <p>No data available.</p>;

    return <Line options={options} data={chartData} />;
};
