// We need the mysql module for node js: https://github.com/mysqljs/mysql
// npm install mysql

//const mysql = require('mysql2');
import mysql from 'mysql2'

// create the connection to database
const connection = mysql.createConnection(
    {
        host:'localhost', 
        user:'BBA', 
        password:'AndyAriYo14', 
        database: 'bam_banimals_adventure_db'
    })

connection.connect(error=>
    {
        if (error) console.log(error)
        console.log('Connected to mysql!')
    })

// rows contains rows returned by server
// fields contains extra meta data about results, if available
connection.query('select * from USER', (error, rows, fields)=> 
    {
        if(error) console.log(error)
        for (const r of rows)
        {
            console.log(Object.keys(r))
            console.log(Object.values(r))
        }
        console.log(rows)
        // console.log(fields)
    })

connection.query('select * from LEVELS', (error, rows, fields)=> 
{
    if(error) console.log(error)
    for (const r of rows)
    {
        console.log(Object.keys(r))
        console.log(Object.values(r))
    }
    console.log(rows)
    // console.log(fields)
})

connection.end(error=>
    {
        if(error) console.log(error)
        console.log("Connection closed successfully!")
    })