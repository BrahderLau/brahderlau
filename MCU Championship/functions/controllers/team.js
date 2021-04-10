const { db } = require('../util/admin')

exports.createNewTeam = (req, res) => {

    const newTeam = {
        teamName: req.body.teamName,
        teamFounder: req.body.teamFounder,
        teamLogo: "sampleImageURL.com",
        createdAt: new Date().toISOString(),
    };

    db.collection('team')
    .add(newTeam)
    .then(doc => {
        res.json({ message: `New team: ${req.body.teamName} created successfully`});
    })
    .catch(err => {
        res.status(500).json({ error: 'Something went wrong'})
        console.error(err);
    })
}