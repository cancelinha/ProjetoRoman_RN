
import React from 'react';
import { View, Text, StyleSheet, Image } from 'react-native';

const styles = StyleSheet.create({
    container: {
        flex: 1,
        flexDirection: 'row',
        padding: 10,
        marginLeft:16,
        marginRight:16,
        marginTop: 8,
        marginBottom: 8,
        borderRadius: 5,
        backgroundColor: '#FFF',
        elevation: 2,
    },
    title: {
        fontSize: 16,
        color: '#000',
    },
    title2:{
        fontSize: 16,
        color: '#000',
        justifyContent:'center'
    },
    container_text: {
        flex: 1,
        flexDirection: 'column',
        marginLeft: 12,
        justifyContent: 'center',
    },
    description: {
        fontSize: 11,
        fontStyle: 'italic',
    },
    datacria: {
        fontSize: 11,
        fontStyle: 'italic',
        alignSelf: 'flex-end'
    }
});

const CustomRow = ({ title, description, dataCriacao }) => (
    <View style={styles.container}>
        <View style={styles.container_text}>
            <Text style={styles.title}>
                {title}
            </Text>
            <Text style={styles.description}>
                {description}
            </Text>
            <Text style={styles.datacria}>
                {dataCriacao}
            </Text>
        </View>

    </View>
);

export default CustomRow;