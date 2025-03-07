import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    // Key configurations for spike in this section
    stages: [
        { duration: '2m', target: 200 }, // fast ramp-up to a high point
        // No plateau
        { duration: '1m', target: 0 }, // quick ramp-down to 0 users
    ],
};

export default () => {
    http.get('http://localhost:5157/makeSpellsGenerated');
    sleep(1);
};
