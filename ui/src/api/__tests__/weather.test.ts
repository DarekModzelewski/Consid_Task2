import { fetchWeatherData } from '../weather';
import { WeatherEntry } from '../../types/WeatherEntry';

const mockResponse: WeatherEntry[] = [
    {
        city: 'London',
        country: 'GB',
        temperature: 11.2,
        updatedAt: '2025-04-07T09:20:29.121792'
    }
];

beforeEach(() => {
    global.fetch = jest.fn();
});

afterEach(() => {
    jest.resetAllMocks();
});

it('fetches weather data and returns array of WeatherEntry', async () => {
    (fetch as jest.Mock).mockResolvedValueOnce({
        ok: true,
        json: async () => mockResponse
    });

    const result = await fetchWeatherData('London');

    expect(fetch).toHaveBeenCalledWith(
        expect.stringContaining(encodeURIComponent('London'))
    );
    expect(result).toEqual(mockResponse);
});

it('throws an error when response is not ok', async () => {
    (fetch as jest.Mock).mockResolvedValueOnce({
        ok: false,
        status: 500
    });

    await expect(fetchWeatherData('London')).rejects.toThrow('Failed to fetch weather for London');
});
