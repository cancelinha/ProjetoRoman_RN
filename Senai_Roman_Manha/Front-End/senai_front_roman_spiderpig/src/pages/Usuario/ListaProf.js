import React, {Component} from 'react';
import {Text, StyleSheet, Image ,View, FlatList, ScrollView, AsyncStorage} from 'react-native';
import CustomRow from './CustomUsu';
import {SearchBar} from 'react-native-elements';
import api from '../../services/api'
import jwt from 'jwt-decode'

class ListaProf extends Component{
    static navigationOptions={
        tabBarIcon: ({tintcolor}) =>{
            <Image
                source={require('../../assets/img/PlusIcon.png')}
                style={styles.iconeNavigatsrProj}
            />
        }
    }
    
    constructor(props){
        super(props);
        this.state = {
            ListaProf: [],
            search: ''
        };
    }

    updateSearch = search => {
        this.setState({ search });
      };

      componentDidMount(){
          this.listarProfessores();
      }


      listarProfessores = async()=>{
        const value = await AsyncStorage.getItem("userToken")
        const answer = await api.get("/usuarios", {
            headers: {
                "Content-Type" : "application/json",
                "Authorization": "Bearer " + value
            }
        });

        const dados = answer.data;
        this.setState({ListaProf: dados});
        
    }
    

    render(){
        return(
            <ScrollView>
            <View style={styles.espaco}>
            <View style={styles.cabecalho}>
            <Text style={styles.titulo}>Professores</Text>
            <View style={styles.linhaTitulo} />
            </View>
            <SearchBar
                placeholder="Type Here..."
                platform='android'
                onChange={this.updateSearch.bind(this)}
                value={this.state.search}
                style={styles.static}
            />
            <Text style={styles.textrecent}>Recentes</Text>
            <View style={styles.linha} />
            <FlatList
                    data={this.state.ListaProf}
                    renderItem={({ item }) => <CustomRow
                        title={item.nome}
                        description={item.email}
                    />}
                />
    
        </View>
        </ScrollView>
        );
    }

    


}   
const styles = StyleSheet.create({
    espaco: {
        flex: 1,
    },
    textrecent:{
        marginLeft: 16,
        marginTop: 16,
        marginBottom: 8
    },
    linha:{
        width: 376,
        marginLeft: 16,
        borderBottomColor: "#999999",
        borderBottomWidth: 0.9,
        marginBottom: 8
    },
    static: {
    },
    titulo: {
        fontSize: 16,
        letterSpacing: 1
    },
    cabecalho: {
        flex: 1,
        justifyContent: "center",
        alignItems: "center",
        marginTop: 16,
        marginBottom:16
    },
    linhaCabecalho: {
        flexDirection: "row"
      },

      linhaTitulo:{
        width: 100,
        borderBottomColor: "#999999",
        borderBottomWidth: 0.9,
        marginBottom: 8,
        marginTop: 2
    }
});

export default ListaProf;
