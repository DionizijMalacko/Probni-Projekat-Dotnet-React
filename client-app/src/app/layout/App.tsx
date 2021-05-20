import React, { Fragment, useEffect } from 'react';
import { ToastContainer } from 'react-toastify';
import ModalContainer from '../common/modals/ModalContainer';
import { Route, Switch } from 'react-router';
import { useStore } from '../stores/store';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import LoadingComponent from './LoadingComponent';
import HomePage from '../../features/home/HomePage';
import LoginForm from '../../features/users/LoginForm';
import NotFound from '../../features/errors/NotFound';
import TestErrors from '../../features/errors/TestError';
import ServerError from '../../features/errors/ServerError';

function App() {

  //location sadrzi u sebi key koji koristimo za pracenje da li nesto promenilo u formi
  //const location = useLocation(); //ako jeste, da bi rerenderovao formu sa praznim poljima
  const {commonStore, userStore} = useStore();

  //useEffect se izvarsava uvek kad se ova komponenta pozove
  useEffect(() => {
    if(commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded());
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore])

  if(!commonStore.appLoaded) return <LoadingComponent content='Loading app...' />
  
  return (
    <Fragment>
      <ToastContainer position='bottom-right' hideProgressBar />
      <ModalContainer />
      <Route exact path='/' component={HomePage}/>
      <Route 
        path={'/(.+)'}
        render={() => (
          <>
            <NavBar />
            <Container style={{marginTop: '10em'}}>
              <Switch>
                {/* <Route exact path='/activities' component={EventDashboard}/>
                <Route path='/activities/:id' component={EventDetails}/>
                <Route key={location.key} path={['/createEvent', '/manage/:id']} component={EventForm}/>
                <Route path='/profiles/:username' component={ProfilePage} /> */}
                <Route path='/errors' component={TestErrors} /> 
                <Route path='/server-error' component={ServerError} /> 
                <Route path='/login' component={LoginForm} />
                <Route component={NotFound} />
              </Switch>
            </Container>
          </>
        )}
      />
    </Fragment>
  );
}

export default App;
