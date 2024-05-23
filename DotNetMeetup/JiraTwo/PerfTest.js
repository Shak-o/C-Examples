import http from 'k6/http';
import exec from 'k6/execution';
import { check } from 'k6';

export const options = {
    stages: [
        { duration: '10s', target: 2 },
        { duration: '20s', target: 5 },
        { duration: '5s', target: 0 },
    ]
};

export default function () {
    const initialCount = 2269;
    var count = exec.scenario.iterationInTest + initialCount;
    
    const url = 'https://localhost:7109/Account';
    const payload = JSON.stringify({
        username: 'perfTestUser' + count,
        password: 'Qwerty1$',
        name:"test",
        lastName:"test",
        email:"em@em.em",
        accountType:0
    });
    
    
    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    var res = http.post(url, payload, params);
    check(res, {
        'is status 200': (r) => r.status === 200,
    });
    
    if (res.status != 200) {
        console.log(res)
    }
}
