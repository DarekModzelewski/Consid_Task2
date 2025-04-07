import React from 'react';
import { WeatherChart } from './components/WeatherChart';

function App() {
    return (
        <div style={{ padding: '2rem' }}>
            <h1>Weather Data</h1>
            <WeatherChart />
        </div>
    );
}

export default App;

