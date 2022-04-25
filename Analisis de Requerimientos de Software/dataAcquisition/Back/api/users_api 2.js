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

app.get('/', (request,response)=>{
    fs.readFile('./html/mysqlUseCases.html', 'utf8', (err, html)=>{
        if(err) response.status(500).send('There was an error: ' + err);
        console.log('Loading page...');
        response.send(html);
    })
});

app.get('/api/users', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from USER', (error, results, fields)=>{
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
app.get('/api/users', (request, response)=>{
    let connection = connectToDB();

    try{

        connection.connect();

        connection.query('select * from USER', (error, results, fields)=>{
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
app.post('/api/users', (request, response)=>{

    try{
        console.log(request.headers);

        let connection = connectToDB();
        connection.connect();

        const query = connection.query('insert into USER set ?', request.body ,(error, results, fields)=>{
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

app.put('/api/users', (request, response)=>{
    try{
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('update USER set Nickname = ? where id_USER= ?', [request.body['Nickname'], request.body['id_USER']] ,(error, results, fields)=>{
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

app.delete('/api/users', (request, response)=>{
    try
    {
        let connection = connectToDB();
        connection.connect();

        const query = connection.query('delete from USER where id_USER = ?', [request.body['id_USER']] ,(error, results, fields)=>{
            if(error) 
                console.log(error);
            else
                response.json({'message': "Data deleted correctly."})
        });

        connection.end();
    }
    catch(error)
    {
        response.json(error);
        console.log(error);
    }
})

app.listen(port, ()=>
{
    console.log(`App listening at http://localhost:${port}`);
});