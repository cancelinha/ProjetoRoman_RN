import {createBottomTabNavigator, createAppContainer, createStackNavigator, createSwitchNavigator} from 'react-navigation';
import Login from './pages/Usuario/Login';
import CadastrarTema from './pages/Temas/CadastroTemas';
import CadastrarProj from './pages/Projetos/Cadastrar';
import ListarProj from './pages/Projetos/ListarProjs';
import ListarTemas from './pages/Temas/ListaTemas';
import ListaProf from './pages/Usuario/ListaProf';

const PrincipalRoute = createBottomTabNavigator(
    {
        CadastrarProj,
        ListarProj,
        Login,
        ListarTemas,
        ListaProf,
        CadastrarTema

    }
);

const toap = createAppContainer(PrincipalRoute);

export default toap;

