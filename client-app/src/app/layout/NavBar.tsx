import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Button, Container, Menu, Image, Dropdown } from 'semantic-ui-react';
import { useStore } from '../stores/store';


export default observer(function NavBar() {
    
    const {userStore : {user, logout}} = useStore();

    //inverted da bi bio crniji, fixed da uvek bude gore
    //exact da bi samo tacno ta ruta bila higlighted
    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/logo.png" alt="logo" style={{marginRight: '10px'}}/>
                    Event App
                </Menu.Item>
                <Menu.Item as={NavLink} to='/events' name="All Events"/>
                <Menu.Item as={NavLink} to='/errors' name="Errors"/>
                <Menu.Item>
                    <Button as={NavLink} to='/createEvent' positive content='Create Event'/>
                </Menu.Item>
                <Menu.Item position='right'>
                    <Image src={user?.image || '/assets/user.png'} avatar spaced='right'/>
                    <Dropdown pointing='top left' text={user?.displayName} >
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`/profiles/${user?.username}`} text='My Profile' icon='user' />
                            <Dropdown.Item onClick={logout} text='Logout' icon='power' />
                        </Dropdown.Menu>
                    </Dropdown>
                </Menu.Item>
            </Container>
        </Menu>
    )
})