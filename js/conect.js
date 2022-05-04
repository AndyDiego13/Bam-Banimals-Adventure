import mysql from 'mysql2'

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
connection.end(error=>
    {
        if(error) console.log(error)
        console.log("Connection closed successfully!")
    })