const { admin, db } = require('../util/admin')

exports.authCheck = (req, res, next) => {
    let idToken;
    if(req.headers.authorization && req.headers.authorization.startsWith('Bearer ')){
      idToken = req.headers.authorization.split('Bearer ')[1]; // to take the token
    } 
    else {
      console.error('No token found')
      return res.status(403).json({ error: 'Unauthorized' });
    }
  
    admin.auth().verifyIdToken(idToken)
      .then(decodedToken => {
        req.user = decodedToken;
        console.log(decodedToken);
        return db.collection('user')
          .where('uid', '==', req.user.uid)
          .limit(1)
          .get();
      })
      .catch(err => {
        console.error('Error while verifying token ', err);
        return res.status(403).json(err);
      })
}
  