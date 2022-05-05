"use strict"

import express from 'express'
import mysql from 'mysql2'
import fs from 'fs'

const app = express();
const port = 5500;

app.use(express.json());

app.use('/js', express.static('./js'))
app.use('/css', express.static('./css'))

function connectToDB()
{
    try{
        return mysql.createConnection({host:'localhost', user:'BBA', password:'AndyAriYo14', database:'bam_banimals_adventure_db'});
    }
    catch(error)
    {
        console.log(error);
    }   
}

// app.get('/', (request,response)=>{
//     fs.readFile('./html/stad.html', 'utf8', (err, html)=>{
//         if(err) response.status(500).send('There was an error: ' + err);
//         console.log('Loading page...');
//         response.send(html);
//     })
// });

// app.get('/api/users', (request, response)=>{
//     let connection = connectToDB();

//     try{

//         connection.connect();

//         connection.query('select * from USER', (error, results, fields)=>{
//             if(error) console.log(error);
//             console.log(JSON.stringify(results));
//             response.json(results);
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.post('/api/users', (request, response)=>{

//     try{
//         console.log(request.headers);

//         let connection = connectToDB();
//         connection.connect();

//         const query = connection.query('insert into USER set ?', request.body ,(error, results, fields)=>{
//             if(error) 
//                 console.log(error);
//             else
//                 response.json({'message': "Data inserted correctly."})
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.put('/api/users', (request, response)=>{
//     try{
//         let connection = connectToDB();
//         connection.connect();

//         const query = connection.query('update USER set Nickname = ? where id_USER= ?', [request.body['Nickname'], request.body['id_USER']] ,(error, results, fields)=>{
//             if(error) 
//                 console.log(error);
//             else
//                 response.json({'message': "Data updated correctly."})
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.get('/api/LEVELS', (request, response)=>{
//     let connection = connectToDB();

//     try{

//         connection.connect();

//         connection.query('select * from LEVELS', (error, results, fields)=>{
//             if(error) console.log(error);
//             console.log(JSON.stringify(results));
//             response.json(results);
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });

// app.get('/api/USER_SCORE', (request, response)=>{
//     let connection = connectToDB();

//     try{

//         connection.connect();

//         connection.query('select * from USER_SCORE', (error, results, fields)=>{
//             if(error) console.log(error);
//             console.log(JSON.stringify(results));
//             response.json(results);
//         });

//         connection.end();
//     }
//     catch(error)
//     {
//         response.json(error);
//         console.log(error);
//     }
// });
app.get('/api/high_score', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from USER_SCORE', (error, results, fields)=>{
            if(error) console.log(error);
            console.log(JSON.stringify(results));
            response.json(results);
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});
app.post('/api/USER_SCORE', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into USER_SCORE set ?' , request.body ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data inserted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});
app.put('/api/USER_SCORE', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('update USER_SCORE set Bambastic = ?, Noice = ?, Keep_trying = ?, Oops = ?, id_USER = ?, id_LEVELS = ? where id_USER_SCORE = ?', [request.body['Bambastic'],request.body['Noice'],request.body['Keep_trying'],request.body['Oops'], request.body['id_USER'],request.body['id_LEVELS'],request.body['id_USER_SCORE']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data updated correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
});

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});