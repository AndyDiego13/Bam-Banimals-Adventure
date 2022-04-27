import mysql from 'mysql2'
import { getRandomName, getRandomWord } from './fetch_random.js'

function randomString(length) 
{
    let result = ''
    let characters= "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
    let charactersLength = characters.length;

    for (let i = 0; i < length; i++ ) 
      result += characters.charAt(Math.floor(Math.random() * charactersLength))
   
   return result
}

const names = await getRandomName(20)
const words = await getRandomWord(10)

const connection = mysql.createConnection(
    {
        host:'localhost', 
        user:'BBA', 
        password:'AndyAriYo14', 
        database: 'bam_banimals_adventure_db'
    }
)

connection.connect(error=>
    {
        if (error) console.log(error)
        console.log('Connected to mysql!')
    }
)


// for(const n of names)
// {
//     let [Nickname] = n.split(" ")
//     const user_data = { Nickname: Nickname}

//     connection.query('insert into USER set ?', user_data, (error, rows, fields)=> 
//     {
//         if(error) console.log(error)
//         console.log(`Added ${Nickname} successfully!`)
//     })
// }


// for(let i = 0; i<20; i++)
// {
//     const TimesPlayed = Math.floor(Math.random() * 100)+1
    
//     const id_LEVELS = {TimesPlayed: TimesPlayed}

//     connection.query('insert into LEVELS set ?', id_LEVELS, (error, rows, fields)=> 
//     {
//         if(error) console.log(error)
//         console.log(`Added attempt successfully!`)
//     })
// }
for(let i = 0; i<20; i++)
{
    const Bambastic = Math.floor(Math.random() * 20)+1
    const Noice = Math.floor(Math.random() * 20)+1
    const Keep_trying = Math.floor(Math.random() * 20)+1
    const Oops = Math.floor(Math.random() * 20)+1

    const user = connection.query('select id_USER from USER', (error, rows, fields)=> 
    {
        if(error) console.log(error)

        let id_users = []
        for (const r of rows)
        {
           id_users.push(r['id_USER'])
        }

        const level = connection.query('select id_LEVELS from LEVELS', (error, rows, fields)=> 
        {
            if(error) console.log(error)
            let id_levels = []
            for (const r of rows)
            {
                id_levels.push(r['id_LEVELS'])
            }

            const id_USER_SCORE = {Bambastic: Bambastic, Noice: Noice, Keep_trying:Keep_trying, Oops:Oops, id_USER: id_users[Math.floor(Math.random() * id_users.length)], id_LEVELS:  id_levels[Math.floor(Math.random() * id_levels.length)]}


            connection.query('insert into USER_SCORE set ?', id_USER_SCORE, (error, rows, fields)=> 
            {
                if(error) console.log(error)
                console.log(`Added attempt successfully!`)
            })
            // console.log(rows)
            // console.log(fields)
        })
    })
    
    // const user = connection.query('select id_USER * from USER')
    // const level = connection.query('select id_LEVELS * from LEVELS')
    // const id_LEVELS = Math.floor(Math.random() * 20)+1

    // const user_level_data = {
    //     id_user: user_id,
    //     id_level: level_id,
    //     attempt_date: attempt_date,
    //     completed:  completed
    // }

   
}

// for(const w of words)
// {
//     const types = ['standard', 'speed run', 'versus']

//     const level_data =
//     {
//          name: w,
//          type: types[Math.floor(Math.random() * types.length)],
//          description: randomString(20),
//          creation_date: new Date()
//     }

//     connection.query('insert into levels set ?', level_data, (error, rows, fields)=> 
//     {
//         if(error) console.log(error)
//         console.log(`Added level ${w} successfully!`)
//     })
// }

/*for(let i = 0; i<20; i++)
{
    const user_id = Math.floor(Math.random() * 20)+1
    const level_id = Math.floor(Math.random() * 10)+1
    const attempt_date = new Date()
    const completed = Math.floor(Math.random() * 2)

    const user_level_data = {
        id_user: user_id,
        id_level: level_id,
        attempt_date: attempt_date,
        completed:  completed
    }

    connection.query('insert into user_level set ?', user_level_data, (error, rows, fields)=> 
    {
        if(error) console.log(error)
        console.log(`Added attempt successfully!`)
    })
}*/

connection.end(error=>
    {
        if(error) console.log(error)
        console.log("Connection closed successfully!")
    })